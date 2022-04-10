import React, { useContext, useEffect } from "react";

import { UserContext } from "src/providers/UserProvider";

const { fetch: originalFetch } = window;

const FetchInitiator = () => {
  const {
    state: { token },
    updateToken,
    logOut,
  } = useContext(UserContext);

  useEffect(() => {
    window.fetch = async (...args) => {
      let [resource, config] = args;
      if (token) {
        config.headers.Authorize = `Bearer ${token}`;
      }

      const response = await originalFetch(resource, config);
      if (response.ok) {
        return await response.json();
      }

      if (response.status === 401) {
        logOut();
      }

      throw new Error(response?.message || "Oops something went wrong");
    };
  }, [token, logOut, updateToken]);

  return <></>;
};

export default FetchInitiator;
