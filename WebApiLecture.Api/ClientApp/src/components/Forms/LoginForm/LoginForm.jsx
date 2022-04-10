import React, { useContext, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { useLogin } from "src/api/useAuth";
import Action from "src/components/Action";

import ControlledInput from "src/components/Input/Controlled";

import { UserContext } from "src/providers/UserProvider";
import { InputName, schema } from "./consts";

import styles from "./login-form.module.scss";

const LoginForm = () => {
  const navigate = useNavigate();
  const { updateToken } = useContext(UserContext);
  const { login } = useLogin();
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm({
    shouldFocusError: false,
    mode: "onChange",
  });

  const onSubmit = async (formValue) => {
    try {
      const response = await login(formValue);
      setError(null);
      setSuccess("Successfully logged in");
      console.log(response);
      
      setTimeout(() => {
        updateToken(response.token);
        navigate("/");
      }, 1000);
    } catch {
      setSuccess(null);
      setError("Invalid credentials");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className={styles.form}>
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
      {success && <span className="success">{success}</span>}
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
