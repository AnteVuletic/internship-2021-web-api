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

      const response = await originalFetch(resource, config);
      if (response.ok) {
        try {
          return await response.json();
        } catch {
          return {};
        }
      }

      if (response.status === 401) {
        logOut();
      }

      throw new Error(response?.message || "Oops something went wrong");
    };

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return <></>;
};

export default FetchInitiator;
