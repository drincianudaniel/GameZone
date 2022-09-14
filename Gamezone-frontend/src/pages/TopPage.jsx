import Header from "../components/Header";
import TopTable from "../components/Tables/TopTable";
import axios from "axios";
import { useEffect, useState } from "react";
import { Container } from "@mui/material";

function TopPage() {
  const [games, setGames] = useState([]);

  useEffect(() => {
    getTop();
  }, []);

  const getTop = async () => {
    await axios
      .get(`${process.env.REACT_APP_SERVERIP}/Games/top`)
      .then((res) => setGames(res.data));
  };

  return (
    <div>
      <Header />
      <Container sx={{ marginTop: 4 }} maxWidth="xl">
        {" "}
        <TopTable games={games} />
      </Container>
    </div>
  );
}

export default TopPage;
