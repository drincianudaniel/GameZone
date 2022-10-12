import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid } from "@mui/material";
import DeveloperService from "../../../api/DeveloperService";

function EditDeveloperForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      name: data.Name,
      headQuarters: data.Headquarters,
    };

    DeveloperService.updateDeveloper(props.id, dataToPost).then((res) => {
      props.getDevelopers();
      props.handleClose();
    });
  };

  useEffect(() => {
    console.log(props);
  });
  return (
    <Box
      sx={{ width: "100%", mt: 1 }}
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
              defaultValue={props.name}
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
              defaultValue={props.headquarters}
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
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default EditDeveloperForm;
