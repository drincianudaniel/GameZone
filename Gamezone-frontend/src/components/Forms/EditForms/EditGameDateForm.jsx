import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid } from "@mui/material";
import GameService from "../../../api/GameService";

function EditGameDateForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    const dataToPost = {
      from: props.date,
      value: data.Date,
    };

    GameService.updateGameDate(props.id, dataToPost).then((res) => {
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
              defaultValue={props.date}
              label="Date"
              name="Date"
              id="fullWidth outlined-multiline-static"
              {...register("Date", {
                required: { value: true, message: "Date is required" },
              })}
              error={!!errors.Date}
              helperText={errors.Date?.message}
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

export default EditGameDateForm;
