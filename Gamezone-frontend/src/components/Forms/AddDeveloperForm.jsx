import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import { Box, Grid } from "@mui/material";
import { toast } from "react-toastify";

function AddDeveloperForm() {
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
      headQuarters: data.Headquarters,
    };

    axios
      .post(`${process.env.REACT_APP_SERVERIP}/developers`, dataToPost)
      .then((response) => {
        toast.success("Developer Added");
        reset();
      })
      .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%", mt: 3 }}
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
        <Grid container spacing={2} maxWidth={400}>
          <Grid item xs={12} md={12}>
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
              error={!!errors.Name}
              helperText={errors.Name?.message}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1 }}
              label="Headquarters"
              name="Headquarters"
              id="fullWidth outlined-multiline-static"
              {...register("Headquarters", {
                required: { value: true, message: "Headquarters is required" },
                maxLength: { value: 50, message: "Headquarters is too long" },
              })}
              error={!!errors.Headquarters}
              helperText={errors.Headquarters?.message}
            />
          </Grid>
        </Grid>
        <Button onClick={() => reset()}>Reset</Button>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default AddDeveloperForm;
