import React from "react";

import styles from "./loader.module.scss";

const Loader = () => {
  return (
    <div className={styles.wrapper}>
      <div className={styles["clock-loader"]} />
    </div>
  );
};

export default Loader;
