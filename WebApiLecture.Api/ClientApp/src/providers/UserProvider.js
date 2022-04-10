import React, { useState, createContext, useCallback } from "react";
import { useNavigate } from "react-router";

import { parseJwt } from "src/utils/token";

const TOKEN_LOCALSTORAGE_KEY = "token";

const initialState = {
  token: null,
  email: null,
  id: null,
};

export const UserContext = createContext({
  state: { ...initialState },
  logOut: () => {},
  updateToken: () => {},
});

const UserProvider = ({ children }) => {
  const navigate = useNavigate();

  const [token, setToken] = useState(
    localStorage.getItem(TOKEN_LOCALSTORAGE_KEY) || null
  );

  const logOut = useCallback(() => {
    setToken(null);
    localStorage.removeItem(TOKEN_LOCALSTORAGE_KEY);
    navigate("/");
  }, [navigate]);

  const updateToken = useCallback((newToken) => {
    setToken(newToken);
    localStorage.setItem(TOKEN_LOCALSTORAGE_KEY, newToken);
  }, []);

  const userData = parseJwt(token);

  const value = {
    state: {
      token,
      email: userData?.email,
      id: userData?.id,
    },
    logOut,
    updateToken,
  };

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};

export default UserProvider;
