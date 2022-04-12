import React from "react";

import RegisterForm from "src/components/Forms/RegisterForm";

import styles from "./register.module.scss";

const Register = () => {
  return (
    <div>
      <h1 className={styles.heading}>Register</h1>
      <RegisterForm />
    </div>
  );
};

export default Register;
