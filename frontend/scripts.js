const api = "http://localhost:5004/api";
var world = [[1, 1, 0, 0, 0], [1, 1, 0, 0, 0], [0, 0, 1, 0, 0], [0, 0, 0, 1, 1]];

function show(divId) {
  var isAsteroid = divId == "asteroids";
  if (isAsteroid) {
    document.querySelector("#asteroids").style.display = "block";
    document.querySelector("#islands").style.display = "none";
    getAsteroidRandomData();
  } else {
    document.querySelector("#asteroids").style.display = "none";
    document.querySelector("#islands").style.display = "block";
    showWorld();
  }
}

async function getAsteroidRandomData() {
  var result = await fetch(`${api}/asteroids`);
  document.querySelector("#asteroids #data").innerHTML = await result.json();
}

async function simulateAsteroids(){
  var data = document.querySelector("#asteroids #data").innerHTML.split(',');
  var result = await fetch(`${api}/asteroids`, {method: 'POST', body: JSON.stringify(data), headers: {"Content-Type": "application/json"}});
  document.querySelector("#asteroids #result").innerHTML = await result.json();
}

async function showWorld(){
  var html = ""
  
  var result = await fetch(`${api}/islands`, {method: 'POST', body: JSON.stringify(world),headers: {"Content-Type": "application/json"}})
  var resultData = await result.json();
  
  for(var i = 0; i < world.length; i++)
  {
    html += "<tr>"
    for(var j = 0; j < world[i].length; j++)
    {
      html+= `<td class='l${i}c${j}'> ${world[i][j]} </td>`
    }
    html += "</tr>" 
  }
  document.querySelector("#islands #table").innerHTML = html;
  
  paintIslands(resultData);
  document.querySelector("#islands #result").innerHTML = `${resultData.length} islands`
}

function paintIslands(islands){
  for(var i = 0; i < islands.length; i++)
  {
    var color = `rgb(${getColorAttr()}, ${getColorAttr()}, ${getColorAttr()})`;
    for (var j = 0; j < islands[i].length; j++)
    {
      document.querySelector(`.l${islands[i][j][0]}c${islands[i][j][1]}`).style.backgroundColor = color; 
    }
  }
}

function getColorAttr() {
  
  return Math.round(Math.random() * 255 + 1);
}
