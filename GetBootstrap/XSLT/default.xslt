<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <meta http-equiv="refresh" content="5"/>
      </head>
      <style>
		  body {
		  background-color:black;
		  color:gray;
		  }
        .table {
        align:center;
        margin-left:5px;
        margin-bottom:5px;
        font-family:Arial, Helvetica, sans-serif;
        width:490px;
        float:left;
		  color:gray;
        }
        .content {
        height: 500px;
        overflow-y:auto;
        }
        .row {
        padding:.5px 1px .5px 1px;
        width:99.5%;
		  border-bottom:1px solid gray;
        }
        .column {
        font-size:12px;
        padding:2px;
        }
		  .DEBUG, .INFO, .WARN, .FATAL, .MAGENTA, .COBALT, .PASS {
		  font-weight:bold;
		  }
		  .MAGENTA, h1 {
		  	color:magenta;
		  }
		  .COBALT {
		  	color:blue;
		  }
		  .DEBUG {
		  color:gray;
		  }
		  .INFO {
		  color:cyan
		  }
		  .WARN, .WARN + .column, .WARN +div +div {
		  color:yellow;
		  }
		 .FATAL, .FATAL + .column, .FATAL +div +div {
		  color:red;
		  }
		  .PASS, .PASS + .column, .PASS +div +div {
		  color:green;
		  }
      </style>
      <body >
        <div style="margin:auto;width:1500px">
			<div>
				<h1>GetBootstrap Logger</h1>
			</div>
          <xsl:for-each select="GetBootstrap/Logger">
            <div class="table">
              <h3 style="margin:auto;padding:10px;">
                <xsl:value-of select="@name"/> Logs
              </h3>
              <div class="content">
                <xsl:for-each select="Log">
      				<xsl:sort select="Date" order="descending"/>
                  <div class="row">

                    <div class="column {Level}">
                      <xsl:value-of select="Level"/>
                    </div>

                    <div class="column">
                      DateTime: <xsl:value-of select="Date"/>
                    </div>

                    <div class="column">
                      Description: <xsl:value-of select="Description"/>
                    </div>

                  </div>
                </xsl:for-each>
              </div>
            </div>
          </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>