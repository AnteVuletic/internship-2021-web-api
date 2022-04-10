import React from "react";
import classNames from "classnames";

import styles from "./input.module.scss";
import Label from "../Label";

const Input = ({
  id,
  value,
  onChange,
  placeholder,
  error,
  label,
  rules,
  type = "text",
  disabled = false,
}) => {
  const handleChange = (event) => {
    if (onChange) {
      onChange(event.target.value);
    }
  };

  return (
    <div className={styles.wrapper}>
      {label && <Label htmlFor={id} text={label} rules={rules} />}
      <input
        id={id}
        type={type}
        value={value}
        onChange={handleChange}
        placeholder={placeholder}
        disabled={disabled}
        className={classNames(styles.input, {
          [styles["input-error"]]: Boolean(error?.message),
        })}
      />
      {error?.message && <span className={styles.error}>{error.message}</span>}
    </div>
  );
};

export default Input;
