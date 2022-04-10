import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";

import ControlledInput from "src/components/Input/Controlled";
import Action from "src/components/Action";
import Loader from "src/components/Loader";

import { useForm } from "react-hook-form";

import { InputName, schema } from "./consts";

import styles from "./todo-form.module.scss";

const TodoForm = ({
  title,
  description,
  handleRequest,
  error,
  isLoading,
  isSuccessful,
}) => {
  const navigate = useNavigate();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm({ mode: "onChange", shouldFocusError: false });

  useEffect(() => {
    if (isSuccessful) {
      setTimeout(() => {
        navigate("/todos");
      }, 2000);
    }
  }, [navigate, isSuccessful]);

  return (
    <form onSubmit={handleSubmit(handleRequest)} className={styles.form}>
      <ControlledInput
        label="Title"
        inputName={InputName.title}
        rules={schema[InputName.title]}
        defaultValue={title || ""}
        control={control}
        error={errors[InputName.title]}
      />
      <ControlledInput
        label="Description"
        inputName={InputName.description}
        rules={schema[InputName.description]}
        defaultValue={description || ""}
        control={control}
        error={errors[InputName.description]}
      />
      {error && <span className="error">{error}</span>}
      {isSuccessful && <span className="success">Successfully added!</span>}
      {!isLoading && (
        <div className={styles.actions}>
          <Action props={{ type: "submit" }}>Save</Action>
        </div>
      )}
      {isLoading && <Loader />}
    </form>
  );
};

export default TodoForm;
