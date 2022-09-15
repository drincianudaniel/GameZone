import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import { Box } from "@mui/material";
import { toast } from "react-toastify";

function AddGenreForm() {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      name: data.Name,
    };

    axios
      .post(`${process.env.REACT_APP_SERVERIP}/genres`, dataToPost)
      .then((response) => {
        toast.success("Genre Added");
        reset();
      })
      .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%" }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <form
        noValidate
        autoComplete="off"
        style={{ marginBottom: 20 }}
        onSubmit={handleSubmit(submit)}
      >
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Name"
          name="Name"
          id="fullWidth outlined-multiline-static"
          {...register("Name", {
            required: { value: true, message: "Name is required" },
            maxLength: { value: 50, message: "Name is too long" },
          })}
          error={!!errors.Content}
          helperText={errors.Content?.message}
        />
        <Button onClick={() => reset()}>Reset</Button>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default AddGenreForm;
