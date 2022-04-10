import React from "react";
import classNames from "classnames";

import { Link } from "react-router-dom";

import styles from "./action.module.scss";

const Action = ({
  variant = "primary",
  renderAs = "button",
  className,
  children,
  props = {
    type: null,
    to: null,
    href: null,
  },
}) => {
  const TagElement = renderAs === "Link" ? Link : renderAs;

  return (
    <TagElement
      className={classNames(
        styles.action,
        styles[`action--${variant}`],
        className
      )}
      {...props}
    >
      {children}
    </TagElement>
  );
};

export default Action;
