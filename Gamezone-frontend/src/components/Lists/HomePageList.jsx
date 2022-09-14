import * as React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import { Box } from "@mui/system";
import { Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function HomePageList(props) {
  return (
    <List sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}>
      {props.data.map((game, i) => {
        return (
          <ListItem key={game.id}>
            <ListItemAvatar>
            <Link to={`/game/${game.id}`} style={{ textDecoration: "none"}}>
              <Box
                component="img"
                src={game.imageSrc}
                sx={{ height: 100, width: 75, objectFit: "cover" }}
              />
              </Link>
            </ListItemAvatar>
            <ListItemText
              sx={{ marginLeft: 0.5 }}
              primary={
                <Link to={`/game/${game.id}`} style={{ textDecoration: "none"}}>
                  <Typography sx={{ fontSize: 18, color: "#1c439b" }}>
                    {game.name}
                  </Typography>
                </Link>
              }
              secondary={
                <Typography sx={{ fontSize: 14 }}>
                  Rating {game.totalRating}/10
                </Typography>
              }
            />
          </ListItem>
        );
      })}
    </List>
  );
}
