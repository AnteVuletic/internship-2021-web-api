import React from "react";

import styles from "./list.module.scss";

const List = ({ columns, rows, error }) => {
  if (error) {
    return <span className="error">{error}</span>;
  }

  return (
    <div className={styles.list}>
      <div className={styles.header}>
        {columns.map((column, index) => (
          <div key={index} className={styles.column}>
            {column}
          </div>
        ))}
      </div>
      <div className={styles.body}>
        {rows.map((elements, index) => (
          <div key={index}>
            {elements.map((element, elementIndex) => (
              <element key={elementIndex} />
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default List;
