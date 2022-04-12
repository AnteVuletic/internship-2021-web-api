import React, { useContext, useEffect, useRef, useCallback } from "react";

import {
  TOKEN_LOCALSTORAGE_KEY,
  UserContext,
} from "src/providers/UserProvider";

const { fetch: originalFetch } = window;

const FetchInitiator = () => {
  const { updateToken, logOut } = useContext(UserContext);

  const tokenPromiseRef = useRef(null);

  const fetchNewToken = () => {
    if (!tokenPromiseRef.current) {
      const token = localStorage.getItem(TOKEN_LOCALSTORAGE_KEY);
      tokenPromiseRef.current = originalFetch(
        `/api/Auth/get-new-token/${token}`,
        {
          method: "GET",
        }
      );
    }

    return tokenPromiseRef.current;
  };

  const handleRefreshToken = useCallback(async () => {
    const response = await fetchNewToken();
    if (response.ok) {
      const responseBodyClone = response.clone();
      const { newToken } = await responseBodyClone.json();
      updateToken(newToken);
    } else {
      logOut();
    }
  }, [logOut, updateToken]);

  useEffect(() => {
    window.fetch = async (...args) => {
      let [resource, config] = args;

      const request = originalFetch(resource, config);
      const response = await request;
      if (response.ok) {
        try {
          return await response.json();
        } catch {
          return {};
        }
      }

      if (response.status === 401) {
        await handleRefreshToken();
      } else {
        throw new Error(response?.message || "Oops something went wrong");
      }
    };
  }, [handleRefreshToken]);

  return <></>;
};

export default FetchInitiator;
