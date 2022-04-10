import React, { useContext } from "react";
import { Route, Routes as RoutesDom, Outlet } from "react-router-dom";
import Layout from "./components/Layout";

import Login from "./pages/Login";
import Register from "./pages/Register";

import Todo from "./pages/Todo";

import { UserContext } from "./providers/UserProvider";

const Main = () => <Outlet />;

const Routes = () => {
  const {
    state: { token },
  } = useContext(UserContext);

  const isLoggedIn = token !== null;

  const application = (
    <Route path="/" element={<Layout />}>
      <Route path="/" element={<Todo />} />
      <Route path="/Todos" element={<Todo />} />
    </Route>
  );

  return (
    <RoutesDom>
      <Route path="/" element={<Main />}>
        {isLoggedIn ? application : <Route path="/" element={<Login />} />}
        <Route path="/register" element={<Register />} />
      </Route>
    </RoutesDom>
  );
};

export default Routes;
