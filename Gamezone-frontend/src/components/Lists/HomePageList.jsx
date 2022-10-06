import * as React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import { Box } from "@mui/system";
import { Typography } from "@mui/material";
import { Link } from "react-router-dom";
import SpinningLoading from "../LoadingComponents/SpinningLoading";

export default function HomePageList(props) {
  return (
    <>
      {!props.data && <SpinningLoading />}
      {props.data && (
        <List
          sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}
        >
          {props.data.map((game, i) => {
            return (
              <ListItem key={game.id}>
                <ListItemAvatar>
                  <Link
                    to={`/game/${game.id}/comments`}
                    style={{ textDecoration: "none" }}
                  >
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
                    <Link
                      to={`/game/${game.id}/comments`}
                      style={{ textDecoration: "none" }}
                    >
                      <Typography sx={{ fontSize: 18, color: "#1c439b" }}>
                        {game.name}
                      </Typography>
                    </Link>
                  }
                  secondary={
                    <Typography sx={{ fontSize: 14 }}>
                      Rating {Math.round(game.totalRating * 10) / 10}/10
                    </Typography>
                  }
                />
              </ListItem>
            );
          })}
        </List>
      )}
    </>
  );
}
