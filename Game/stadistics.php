<?php
include "dbConnection.php";

try{
    $conn = mysqli_connect($db_servidor, $db_usuario, $db_pass, $db_baseDatos);

	if(!$conn){
		echo'{"codigo":400, "mensaje": "Error al conectar a la Base de datos"}';
	}else{
        if(isset($_POST['usuario'])){
            $count=0;
            $usuario = $_POST['usuario'];
            $texto="";
            $sql = "SELECT * FROM `partida` WHERE idUsuario = (SELECT idUsuario FROM `usuario`WHERE username = '".$usuario."');";
            $resultado = $conn -> query($sql);
            if($resultado->num_rows> 0){
                while($count<$resultado->num_rows){
                    while($row = $resultado ->fetch_assoc()){
                        $texto .= '{#idPartida#:'.$row['idPartida'].', #usuario#:#'.$usuario.'#, #equipo#:#'.$row['equipo'].'#, #duracion#:#'.$row['duracion'].'#, #dificultad#:#'.$row['dificultad'].'#, #ganado#:'.$row['gando'].'},';
                    }
                    $count=$count+1;
                }
                echo'{"codigo":205,"mensaje":"Estadisticas recuperadas","respuesta":['.$texto.']}';
            }else{
                echo'{"codigo":303,"mensaje":"El usuario no tiene partidas registradas","respuesta":""}';
            }
                
        }else{
            echo'{"codigo":405,"mensaje":"Completa todos los campos","respuesta":""}';
        }
    }
}catch (Exepcion $e){
	echo'{"codigo":400,"mensaje":"Error al conectar a la Base de datos","respuesta":""}';
}
?>