export const InputName = Object.freeze({
  title: "title",
  description: "description",
});

export const schema = {
  [InputName.title]: {
    required: "Title is required",
  },
  [InputName.description]: {
    required: "Description is required",
  },
};
