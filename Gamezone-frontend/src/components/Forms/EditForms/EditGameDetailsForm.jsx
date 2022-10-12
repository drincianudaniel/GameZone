import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid } from "@mui/material";
import GameService from "../../../api/GameService";

function EditGameDetailsForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      from: props.details,
      value: data.Details,
    };

    GameService.updateGameDetails(props.id, dataToPost).then((res) => {
      props.getGame();
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
        <Grid container spacing={2}>
          <Grid item xs={12} md={12}>
            <TextField
              fullWidth
              multiline
              required
              rows={10}
              sx={{ marginBottom: 1, width: { md: "500px", sx: "400px" } }}
              defaultValue={props.details}
              label="Details"
              name="Details"
              id="fullWidth outlined-multiline-static"
              {...register("Details", {
                required: { value: true, message: "Details is required" },
                minLength: {
                  value: 20,
                  message: `Details too short, min 20 characters`,
                },
                maxLength: { value: 1000, message: "Details is too long" },
              })}
              error={!!errors.Details}
              helperText={errors.Details?.message}
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

export default EditGameDetailsForm;
