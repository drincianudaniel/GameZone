import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid } from "@mui/material";
import PlatformService from "../../../api/PlatformService";

function EditPlatformForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      name: data.Name,
    };

    PlatformService.updatePlatform(props.id, dataToPost).then((res) => {
      props.getGenres();
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
              sx={{ marginBottom: 1, width: { md: "400px", sx: "300px" } }}
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
        </Grid>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default EditPlatformForm;
