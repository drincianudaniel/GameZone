import React, { useState } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import Rating from "@mui/material/Rating";

function PostReviewForm(props) {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const [value, setValue] = useState(0);

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      userId: "02ea0508-999e-4cb0-29a9-08da7ea2b5b5",
      gameId: props.id,
      rating: value * 2,
      content: data.Content,
    };

    axios
      .post(`${process.env.REACT_APP_SERVERIP}/reviews`, dataToPost)
      .then((response) => {
        props.getReviews();
        reset();
        setValue(0);
        props.getGame();
      })
      .catch((err) => console.log(err));
  };

  return (
    <form
      autoComplete="off"
      style={{ marginBottom: 20 }}
      onSubmit={handleSubmit(submit)}
    >
      <Rating
        name="simple-controlled"
        value={value}
        onChange={(event, newValue) => {
          setValue(newValue);
        }}
        precision={0.1}
      />

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
        })}
        error={!!errors.Content}
        helperText={errors.Content?.message}
      />
      <Button onClick={() => reset()}>Reset</Button>
      <Button type="submit" variant="contained">
        Submit
      </Button>
    </form>
  );
}

export default PostReviewForm;
