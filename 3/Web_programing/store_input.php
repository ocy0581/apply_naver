<!DOCTYPE html>
<html>
<head> 
<meta charset="utf-8">
<title>PHP 프로그래밍 입문</title>
<link rel="stylesheet" type="text/css" href="./css/common.css?ver=2">
<link rel="stylesheet" type="text/css" href="./css/member.css?ver=2">

</head>
<body> 
	<header>
		<?php include "header.php";?>
    <?php 
    if (isset($_SESSION["userid"])) $userid = $_SESSION["userid"];
    else $userid = "";
    if (isset($_SESSION["username"])) $username = $_SESSION["username"];
    else $username = "";

    if ( !$userid )
    {
        echo("
                    <script>
                    alert('가게 추가하기는 로그인 후 이용해 주세요!');
                    location.href='/index.php';
                    </script>
        ");
                exit;
    }
		if(isset($_POST["swX"]))
		$swX = $_POST["swX"];
		else {
			$swX=0;
		}
		if(isset($_POST["swY"]))
		$swY = $_POST["swY"];
		else {
			$swY = 0;
		}
		if(isset($_POST["neX"]))
		$neX = $_POST["neX"];
		else {
			$neX=0;
		}
		if(isset($_POST["neY"]))
		$neY = $_POST["neY"];
		else {
			$neY = 0;
		}

		if(!$swX  || !$swY || !$neX || !$neY)
		{
			echo("
						<script>
						alert('좌표입력 오류');
						history.go(-1)
						</script>
			");
					exit;
		}

        $swx_cookey = setcookie("swX",$swX);            
		$swy_cookey = setcookie("swY",$swY);
		
        $nex_cookey = setcookie("neX",$neX);            
        $ney_cookey = setcookie("neY",$neY);
		// echo "$tmp asdasdasdasdasd";
    ?>
        
    </header>
	<section>
		<div id="main_img_bar">
            <img src="./img/main_img.png">
        </div>
        <div id="main_content">
      		<div id="join_box">
          	<form  name="store_form" method="post" action="store_insert.php" enctype="multipart/form-data">
			    <h2>가게 추가하기</h2>
    		    	<div class="form name">
				        <div class="col1">가게이름</div>
				        <div class="col2">
							<input type="text" name="name" value="">
				        </div>  
			       	</div>
			       	<div class="clear"></div>

			       	<div class="form">
				        <div class="col1">타입</div>
				        <div class="col2">
							<input type="text" name="type" value="">
				        </div>                 
			       	</div>
			       	<div class="clear"></div>
			       	<div class="form">
				        <div class="col1">배달 팁</div>
				        <div class="col2">
							<input type="text" name="deliveryTip" value="">
				        </div>                 
			       	</div>
			       	<div class="clear"></div>
			       	<div class="form">
				        <div class="col1">최소 주문금액</div>
				        <div class="col2">
							<input type="text" name="minprice" value="">
				        </div>                 
			       	</div>
                       <div class="clear"></div>
                       <div class="form">

                       <span class="col1"> 첨부 파일</span>
                        <span class="col2"><input type="file" name="upfile" value=""></span>
	
                       </div>
                    <div class="clear"></div>
					   <div class="bottom_line"> </div>
			       	<div class="buttons">
	                	<img style="cursor:pointer" src="./img/button_save.gif" onclick="check_input()">&nbsp;
                  		<img id="reset_button" style="cursor:pointer" src="./img/button_reset.gif"
                  			onclick="reset_form()">
	           		</div>
           	</form>
        	</div> <!-- join_box -->
        </div> <!-- main_content -->
	</section> 
	<footer>
    	<?php include "footer.php";?>
    </footer>
</body>
</html>



<script>
   function check_input()
   {
      if (!document.store_form.name.value) {
          alert("가게이름을 입력하세요!");    
          document.store_form.name.focus();
          return;
      }
      if (!document.store_form.type.value) {
          alert("타입을 입력하세요!");    
          document.store_form.type.focus();
          return;
      }

	  var str = document.store_form.name.value;
	  if(str.indexOf(" ") !== -1)
	  {
		  alert("가게 이름에 빈칸이 없어야 합니다.")
		  document.store_form.type.focus();
		  return;
		  
	  }
      document.store_form.submit();
   }

   function reset_form() {
      document.store_form.name.value = "";  
      document.store_form.type.value = "";
      document.store_form.minprice.value = "";
      document.store_form.deliveryTip.value = "";
      document.store_form.upfile.value = "";
      document.store_form.name.focus();
      return;
   }

</script>