import React, { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { UserContext } from "src/providers/UserProvider";
import Navigation from "../Navigation";

const Layout = () => {
  const {
    state: { token },
  } = useContext(UserContext);

  if (!token) {
    return <Navigate to="/" />;
  }

  return (
    <div>
      <Navigation />
      <Outlet />
    </div>
  );
};

export default Layout;
