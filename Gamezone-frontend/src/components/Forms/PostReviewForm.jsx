import React, { useState } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import Rating from "@mui/material/Rating";
import { useUser } from "../../hooks/useUser";
import ReviewService from "../../api/ReviewService";
import { FormControl, FormHelperText, InputLabel, MenuItem, Select } from "@mui/material";
import { toast } from "react-toastify";

function PostReviewForm(props) {
  const { user } = useUser();

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
      gameId: props.id,
      rating: data.Rating,
      content: data.Content,
    };

    ReviewService.postReview(dataToPost)
      .then((response) => {
        props.getReviews();
        reset();
        props.getGame();
      })
      .catch((err) => toast.error(err.response.data));
  };

  return (
    <form
      noValidate
      autoComplete="off"
      style={{ marginBottom: 20 }}
      onSubmit={handleSubmit(submit)}
    >
      <FormControl sx={{ width: "50%", mb: 2 }}>
        <InputLabel id="demo-simple-select-label">Rating *</InputLabel>
        <Select
          defaultValue={5}
          {...register("Rating", {
            required: { value: true, message: "Content is required" },
          })}
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          label="Rating"
          name="Rating"
        >
          <MenuItem value={1}>(1) Appaling</MenuItem>
          <MenuItem value={2}>(2) Horrible</MenuItem>
          <MenuItem value={3}>(3) Very Bad</MenuItem>
          <MenuItem value={4}>(4) Bad</MenuItem>
          <MenuItem value={5}>(5) Average</MenuItem>
          <MenuItem value={6}>(6) Fine</MenuItem>
          <MenuItem value={7}>(7) Good</MenuItem>
          <MenuItem value={8}>(8) Very Good</MenuItem>
          <MenuItem value={9}>(9) Great</MenuItem>
          <MenuItem value={10}>(10) Masterpiece</MenuItem>
        </Select>
        {!!errors.Content && (
          <FormHelperText error id="accountId-error">
            {errors.Content?.message}
          </FormHelperText>
        )}
      </FormControl>

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
