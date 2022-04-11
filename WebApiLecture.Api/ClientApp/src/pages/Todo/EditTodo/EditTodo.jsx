import React from "react";
import { useParams } from "react-router-dom";
import { useGetTodoDetail, usePutTodo } from "src/api/useTodo";
import TodoForm from "src/components/Forms/TodoForm";

import Loader from "src/components/Loader";

import styles from './edit-todo.module.scss';

const EditTodo = () => {
  const { id } = useParams();
  const { data: todoDetail, error: todoDetailError, isLoading: todoDetailIsLoading } = useGetTodoDetail(id);
  const putTodo = usePutTodo(id);

  if (todoDetailIsLoading) {
    return <Loader />
  }

  if (todoDetailError) {
    return <span className='error'>Issue getting todo details</span>
  }

  return <div className={styles.wrapper}>
    <h1 className={styles.heading}>Todo details</h1>
    <TodoForm {...todoDetail} {...putTodo} />
  </div>;
};

export default EditTodo;
