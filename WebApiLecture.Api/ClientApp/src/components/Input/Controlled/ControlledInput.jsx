import React from "react";

import { Controller } from "react-hook-form";

import Input from "../Input";

const ControlledInput = ({
  inputName,
  rules,
  control,
  defaultValue,
  error,
  label,
  disabled = false,
  inputType = "text",
}) => {
  return (
    <Controller
      name={inputName}
      defaultValue={defaultValue || ""}
      control={control}
      rules={rules}
      render={({ field: { onChange, value } }) => (
        <Input
          id={inputName}
          value={value}
          onChange={onChange}
          error={error}
          disabled={disabled}
          label={label}
          type={inputType}
          rules={rules}
        />
      )}
    />
  );
};

export default ControlledInput;
