import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Paper } from "@mui/material";

function LoginForm() {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    // const dataToPost = {
    //   username: data.Name,
    //   password: data.Password,
    // };

    // axios
    //   .post(`${process.env.REACT_APP_SERVERIP}/genres`, dataToPost)
    //   .then((response) => {
    //     console.log(response);
    //     toast.success("Genre Added");
    //     reset();
    //   })
    //   .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%", height: "100%" }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <Paper sx={{padding:1}}>
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
            label="Username"
            name="Username"
            id="fullWidth outlined-multiline-static"
            {...register("Username", {
              required: { value: true, message: "Username is required" },
            })}
            error={!!errors.Username}
            helperText={errors.Username?.message}
          />
          <TextField
            fullWidth
            required
            sx={{ marginBottom: 1 }}
            label="Password"
            name="Password"
            id="fullWidth outlined-multiline-static"
            {...register("Password", {
              required: { value: true, message: "Password is required" },
            })}
            error={!!errors.Password}
            helperText={errors.Password?.message}
          />
          <Box
            sx={{ width: "100%", display: "flex", justifyContent: "center" }}
          >
            {" "}
            <Button type="submit" variant="contained">
              Submit
            </Button>
          </Box>
        </form>
      </Paper>
    </Box>
  );
}

export default LoginForm;
