import * as React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import Avatar from "@mui/material/Avatar";
import ImageIcon from "@mui/icons-material/Image";
import WorkIcon from "@mui/icons-material/Work";
import BeachAccessIcon from "@mui/icons-material/BeachAccess";
import { Box } from "@mui/system";
import { Typography } from "@mui/material";

export default function HomePageList(props) {
  return (
    <List sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}>
      {props.data.map((game, i) => {
        return (
            <ListItem >
              <ListItemAvatar>
                <Box
                  component="img"
                  src={game.imageSrc}
                  sx={{ height: 100, width: 75 }}
                />
              </ListItemAvatar>
              <ListItemText primary={game.name} secondary={game.totalRating} />
            </ListItem>
        );
      })}
    </List>
  );
}
