import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";

function PostCommentForm(props) {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm({ shouldUseNativeValidation: true });

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      userId: "02ea0508-999e-4cb0-29a9-08da7ea2b5b5",
      gameId: props.id,
      content: data.Content,
    };

    axios
      .post(`${process.env.REACT_APP_SERVERIP}/comments`, dataToPost)
      .then((response) => props.getComments())
      .catch((err) => console.log(err));
  };

  return (
    <form
      autoComplete="off"
      style={{ marginBottom: 20 }}
      onSubmit={handleSubmit(submit)}
    >
      <TextField
        fullWidth
        multiline
        required
        rows={4}
        sx={{ marginBottom: 1 }}
        label="Content"
        name="Content"
        id="fullWidth outlined-multiline-static"
        {...register("Content", {
          required: { value: true, message: "Content is required" },
          maxLength: { value: 500, message: "Content is too long" },
          minLength: { value: 20, message: "Content is too short" },
        })}
        error={!!errors.name}
        helperText={errors.name?.message}
      />
      <Button onClick={() => reset()}>Reset</Button>
      <Button type="submit" variant="contained">
        Submit
      </Button>
    </form>
  );
}

export default PostCommentForm;
