import { Container } from "@mui/material";
import { Box } from "@mui/system";
import LoginForm from "../components/Forms/LoginForm";
import RegisterForm from "../components/Forms/RegisterForm";
import Header from "../components/Header";

function RegisterPage() {
  return (
    <div>
      <Box
        sx={{
          height: "100vh",
          background:
            "linear-gradient(-45deg, #000000, #00177a, #227fd6, #bce9f7)",
          backgroundSize: "400% 400%",
          animation: "gradient 20s ease infinite",
        }}
      >
        <Header />
        <Container sx={{ height: "90vh" }} maxWidth="xs">
          <RegisterForm />
        </Container>
      </Box>
    </div>
  );
}

export default RegisterPage;
