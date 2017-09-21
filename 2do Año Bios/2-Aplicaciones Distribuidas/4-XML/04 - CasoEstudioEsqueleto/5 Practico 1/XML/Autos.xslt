<?xml version="1.0" encoding="utf-8"?>
  <xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!-- Determino que el formato se aplica en todo el doc-->
  <xsl:template match="/">
    <table>
      <!-- Determino como quiero desplegar cada nodo libro-->
      <xsl:for-each select="Autos/Auto">
        <!--Para cada libro creo dos renglones de despliegue-->
        <tr>
          <!-- Primero el titulo-->
          <td style="background-color:Blue;padding:4px;font-size:15pt;font-weight:bold;color:white">
            Matricula <xsl:value-of select="Matricula"/>
          </td>
          <!-- Segundo desplie el ISBN y la cat-->
          <td style="margin-left:20px;margin-bottom:1em;font-size:15pt">
            Marca <xsl:value-of select="Marca"/>
          </td>
          <!-- Segundo desplie el ISBN y la cat-->
          <td style="margin-left:20px;margin-bottom:1em;font-size:15pt">
            Modelo <xsl:value-of select="Modelo"/>
          </td>
          <!-- Segundo desplie el ISBN y la cat-->
          <td style="margin-left:20px;margin-bottom:1em;font-size:15pt">
            Duenio <xsl:value-of select="Duenio"/>
          </td>
          <!-- Segundo desplie el ISBN y la cat-->

          <xsl:choose>
            <xsl:when test="Precio &lt;= 15000">
              <td bgcolor="#ff00ff">
                <xsl:value-of select="Precio"/>
              </td>
            </xsl:when>
            <xsl:otherwise>
              <td>
                <xsl:value-of select="Precio"/>
              </td>
            </xsl:otherwise>
          </xsl:choose>
          
          
          
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
