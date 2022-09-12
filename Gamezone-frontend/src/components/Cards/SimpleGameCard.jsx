import * as React from "react";
import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import { Link } from "react-router-dom";

export default function SimpleGameCard(props) {
  return (
    <Card className="gameCard" sx={{ maxWidth: 300 }}>
      <Link
        style={{ textDecoration: "none", color: "black" }}
        to={`/game/${props.data.id}`}
      >
        <CardHeader sx={{fontSize: 10}} title={props.data.name} />
        <CardMedia
          sx={{ width: 300 }}
          component="img"
          height="350"
          image={props.data.imageSrc}
        />
      </Link>
    </Card>
  );
}
