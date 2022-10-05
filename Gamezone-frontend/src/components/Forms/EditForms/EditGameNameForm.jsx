import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid } from "@mui/material";
import GameService from "../../../api/GameService";

function EditGameNameForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    const dataToPost = {
      from: props.name,
      value: data.Name,
    };

    GameService.updateGameName(props.id, dataToPost).then((res) => {
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
              required
              sx={{ marginBottom: 1, width: { md: "500px", sx: "400px" } }}
              defaultValue={props.name}
              label="Name"
              name="Name"
              id="fullWidth outlined-multiline-static"
              {...register("Name", {
                required: { value: true, message: "Name is required" },
                minLength: {
                  value: 0,
                  message: `Name too short`,
                },
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

export default EditGameNameForm;
