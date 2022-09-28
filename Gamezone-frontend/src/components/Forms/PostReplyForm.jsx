import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import { useUser } from "../../hooks/useUser";
import ReplyService from "../../api/ReplyService";

function PostReplyForm(props) {
  const {user} = useUser();
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      userId: user.Id,
      commentId: props.commentId,
      content: data.Content,
    };

   ReplyService.postReply(dataToPost)
      .then((response) => {
        props.getReplies();
        reset();
      })
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

export default PostReplyForm;
