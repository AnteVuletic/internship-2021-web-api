import React from "react";

import LoginForm from "src/components/Forms/LoginForm";

import styles from "./login.module.scss";

const Login = () => {
  return (
    <div>
      <h1 className={styles.heading}>Login</h1>
      <LoginForm />
    </div>
  );
};

export default Login;
