import React, { useEffect } from "react";
import { useDeleteTodo, useGetTodos } from "src/api/useTodo";
import Action from "src/components/Action";

import List from "src/components/List";
import Loader from "src/components/Loader";

import styles from "./todo.module.scss";

const Todo = () => {
  const columns = ["Title", "Description", "Actions"];
  const { data, error, isLoading, triggerReload } = useGetTodos();
  const {
    handleRequest: handleDelete,
    error: deleteError,
    isLoading: isDeleteLoading,
    isSuccessful: isDeleteSuccessful,
  } = useDeleteTodo();

  useEffect(() => {
    if (isDeleteSuccessful) {
      triggerReload();
    }
  }, [isDeleteSuccessful, triggerReload]);

  const isLoaderVisible = isLoading || isDeleteLoading;

  const rows = data
    ? data.map((data) => [
        <span>{data.title}</span>,
        <span>{data.description}</span>,
        <div>
          <Action
            renderAs="Link"
            variant="info"
            props={{ to: `/todos/${data.id}` }}
          >
            Edit
          </Action>

          <Action
            variant="danger"
            props={{
              onClick: () => {
                handleDelete(null, `/${data.id}`);
              },
            }}
          >
            Delete
          </Action>
        </div>,
      ])
    : [];

  return (
    <div className={styles.wrapper}>
      <div className={styles.heading}>
        <h1>Todos</h1>
        <Action renderAs="Link" props={{ to: "/todos/add" }}>
          Add todo
        </Action>
      </div>
      <div>
        {deleteError && <span className="error">{deleteError}</span>}
        {isLoaderVisible && <Loader />}
        {!isLoaderVisible && (
          <List columns={columns} rows={rows} error={error} />
        )}
      </div>
    </div>
  );
};

export default Todo;
