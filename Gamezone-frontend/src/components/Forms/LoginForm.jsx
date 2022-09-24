import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Paper } from "@mui/material";
import UserService from "../../api/UserService";
import { toast } from "react-toastify";
import { useUser } from "../../hooks/useUser";
import jwt_decode from "jwt-decode";
import { useNavigate } from "react-router";

function LoginForm() {

  const {setUser, user, setToken} = useUser();
  const history = useNavigate();

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      username: data.Username,
      password: data.Password,
    };

    UserService.Login(dataToPost)
      .then((res) => {
        console.log(res);
        setToken(res.data);
        setUser(jwt_decode(res.data));
        console.log(user)
        history("/")
        localStorage.setItem('jwt', res.data);
      })
      .catch(err => toast.error("Invalid username or password"));
  };

  return (
    <Box
      sx={{ width: "100%", height: "100%" }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <Paper elevation={24} sx={{ padding: 1 }}>
        <form noValidate autoComplete="off" onSubmit={handleSubmit(submit)}>
          <TextField
            fullWidth
            required
            sx={{ marginBottom: 1, mt: 1 }}
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
            type="password"
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
