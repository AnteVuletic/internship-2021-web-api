import React, { useContext, useEffect } from "react";
import { useForm } from "react-hook-form";
import { useLogin } from "src/api/useAuth";
import Action from "src/components/Action";

import ControlledInput from "src/components/Input/Controlled";
import Loader from "src/components/Loader";

import { UserContext } from "src/providers/UserProvider";
import { InputName, schema } from "./consts";

import styles from "./login-form.module.scss";

const LoginForm = () => {
  const { updateToken } = useContext(UserContext);
  const { handleRequest, data, error, isLoading, isSuccessful } = useLogin();

  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm({
    shouldFocusError: false,
    mode: "onChange",
  });

  useEffect(() => {
    if (isSuccessful) {
      setTimeout(() => {
        updateToken(data.token);
      }, 2000);
    }
  }, [isSuccessful, updateToken, data]);

  if (isLoading) {
    return <Loader />;
  }

  return (
    <form onSubmit={handleSubmit(handleRequest)} className={styles.form}>
      <ControlledInput
        inputName={InputName.email}
        rules={schema[InputName.email]}
        error={errors[InputName.email]}
        control={control}
        label="Email"
      />
      <ControlledInput
        inputName={InputName.password}
        rules={schema[InputName.password]}
        error={errors[InputName.password]}
        control={control}
        label="Password"
        inputType="password"
      />
      {error && <span className="error">{error}</span>}
      {isSuccessful && <span className="success">Success!</span>}
      <div className={styles.actions}>
        <Action variant="info" renderAs="Link" props={{ to: "/register" }}>
          Register
        </Action>
        <Action variant="primary" props={{ type: "submit" }}>
          Login
        </Action>
      </div>
    </form>
  );
};

export default LoginForm;
