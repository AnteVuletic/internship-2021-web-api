import React from "react";

import FetchInitiator from "./components/FetchInitiator";
import UserProvider from "./providers/UserProvider";

import Routes from "./Routes";

const App = () => {
  return (
    <UserProvider>
      <FetchInitiator />
      <Routes />
    </UserProvider>
  );
};

export default App;
