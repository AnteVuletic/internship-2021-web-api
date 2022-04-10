import React, { useContext } from "react";
import { UserContext } from "src/providers/UserProvider";

import Action from "../Action";

import styles from "./navigation.module.scss";

const Navigation = () => {
  const {
    state: { email },
  } = useContext(UserContext);

  return (
    <ul className={styles.navigation}>
      <li>{email}</li>
      <li>
        <Action renderAs="Link" variant="info" props={{ to: "/todos" }}>
          Todos
        </Action>
      </li>
    </ul>
  );
};

export default Navigation;
