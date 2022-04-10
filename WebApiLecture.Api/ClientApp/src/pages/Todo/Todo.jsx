import React from "react";
import { useGetTodos } from "src/api/useTodo";
import Action from "src/components/Action";

import List from "src/components/List";
import Loader from "src/components/Loader";

import styles from "./todo.module.scss";

const Todo = () => {
  const columns = ["Title", "Description"];
  const { data, error, isLoading } = useGetTodos();

  if (isLoading) {
    return <Loader />;
  }

  const rows = data
    ? data.map((data) => [
        <span>{data.title}</span>,
        <span>{data.description}</span>,
      ])
    : [];

  return (
    <div className={styles.wrapper}>
      <div className={styles.heading}>
        <h1>Todos</h1>
        <Action renderAs='Link' props={{ to: '/todos/add'}}>Add todo</Action>
      </div>
      <div>
        <List columns={columns} rows={rows} error={error} />
      </div>
    </div>
  );
};

export default Todo;
