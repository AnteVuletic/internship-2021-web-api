import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { useRegister } from "src/api/useAuth";
import Action from "src/components/Action";

import ControlledInput from "src/components/Input/Controlled";
import Loader from "src/components/Loader";

import { InputName, schema } from "./consts";

import styles from "./register-form.module.scss";

const RegisterForm = () => {
  const navigate = useNavigate();
  const { handleRequest, error, isLoading, isSuccessful } = useRegister();
  const {
    control,
    handleSubmit,
    formState: { errors },
    getValues,
  } = useForm({
    shouldFocusError: false,
    mode: "onChange",
  });

  useEffect(() => {
    if (isSuccessful) {
      setTimeout(() => {
        navigate("/");
      }, 2000);
    }
  }, [isSuccessful, navigate]);

  if (isLoading) {
    return <Loader />;
  }

  const passwordMatchValidate = {
    validate: (value) =>
      getValues(InputName.password) === value || "Passwords do not match",
  };

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
      <ControlledInput
        inputName={InputName.repeatPassword}
        rules={passwordMatchValidate}
        error={errors[InputName.repeatPassword]}
        control={control}
        label="Repeat password"
        inputType="password"
      />
      {error && <span className="error">{error}</span>}
      {isSuccessful && (
        <span className="success">Successfully registered!</span>
      )}
      <div className={styles.actions}>
        <Action variant="info" renderAs="Link" props={{ to: "/" }}>
          Login
        </Action>
        <Action variant="primary" props={{ type: "submit" }}>
          Register
        </Action>
      </div>
    </form>
  );
};

export default RegisterForm;
