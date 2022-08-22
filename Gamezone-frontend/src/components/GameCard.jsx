import * as React from "react";
import { styled } from "@mui/material/styles";
import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ShareIcon from "@mui/icons-material/Share";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

export default function GameCard(props) {
  const [expanded, setExpanded] = React.useState(-1);

  const handleExpandClick = (i) => {
    setExpanded(expanded === i ? -1 : i);
    console.log(i);
  };

  return (
    <Card className="gameCard" sx={{ maxWidth: 345 }}>
      <CardHeader title={props.data.name} />
      <CardMedia
        sx={{ width: 300 }}
        component="img"
        height="350"
        image={props.data.imageSrc}
      />
      <CardActions disableSpacing>
        <IconButton aria-label="add to favorites">
          <FavoriteIcon />
        </IconButton>
        <IconButton aria-label="share">
          <ShareIcon />
        </IconButton>
      </CardActions>
    </Card>
  );
}
