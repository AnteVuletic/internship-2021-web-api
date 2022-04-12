import React from "react";

import styles from "./label.module.scss";

const Label = ({ htmlFor, text, rules }) => {
  const isRequired = Boolean(rules?.required);

  return (
    <label className={styles.label} htmlFor={htmlFor}>
      {text} {isRequired && <span className={styles.astrix}>*</span>}
    </label>
  );
};

export default Label;
