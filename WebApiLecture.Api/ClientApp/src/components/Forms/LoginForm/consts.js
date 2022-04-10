export const InputName = Object.freeze({
  email: "email",
  password: "password",
});

export const schema = {
  [InputName.email]: {
    required: "Email is required",
  },
  [InputName.password]: {
    required: "Password is required",
  },
};
