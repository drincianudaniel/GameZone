import * as React from "react";
import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import { Link } from "react-router-dom";

export default function SimpleGameCard(props) {
  return (
    <Card
      sx={{
        maxWidth: 200,
        "&:hover": { boxShadow: "0 0 11px rgba(33,33,33,.2)" },
      }}
    >
      <Link
        style={{ textDecoration: "none", color: "black" }}
        to={`/game/${props.data.id}`}
      >
        <CardHeader
          sx={{
            display: "flex",
            overflow: "hidden",
            "& .MuiCardHeader-content": {
              overflow: "hidden",
            },
          }}
          titleTypographyProps={{ variant: "h7", noWrap: true }}
          title={props.data.name}
        />
        <CardMedia
          sx={{ width: 200 }}
          component="img"
          height="270"
          image={props.data.imageSrc}
        />
      </Link>
    </Card>
  );
}
