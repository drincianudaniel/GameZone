import { Container } from "@mui/material";
import LoginForm from "../components/Forms/LoginForm";
import Header from "../components/Header";

function LoginPage() {
  return (
    <div>
      <Header />
      <Container sx={{ height:"90vh" }} maxWidth="xs">
        <LoginForm/>
      </Container>
    </div>
  );
}

export default LoginPage;
