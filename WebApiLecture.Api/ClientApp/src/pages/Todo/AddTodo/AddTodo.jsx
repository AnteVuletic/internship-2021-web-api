import React from "react";

import TodoForm from "src/components/Forms/TodoForm";

import { useAddTodo } from "src/api/useTodo";

import styles from "./add-todo.module.scss";

const AddTodo = () => {
  const formProps = useAddTodo();

  return (
    <div className={styles.wrapper}>
      <h1 className={styles.heading}>Add todo</h1>
      <TodoForm {...formProps} />
    </div>
  );
};

export default AddTodo;
