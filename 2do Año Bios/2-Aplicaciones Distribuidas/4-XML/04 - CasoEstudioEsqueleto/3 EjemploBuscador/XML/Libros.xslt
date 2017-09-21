<?xml version="1.0" encoding="utf-8"?>
  <xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <!-- Determino que el formato se aplica en todo el doc-->
  <xsl:template match="/">
    <table>
      <!-- Determino como quiero desplegar cada nodo libro-->
      <xsl:for-each select="Biblioteca/Libro">
        <!--Para cada libro creo dos renglones de despliegue-->
        <tr>
          <!-- Primero el titulo-->
          <td style="background-color:Blue;padding:4px;font-size:15pt;font-weight:bold;color:white">
            Titulo <xsl:value-of select="Titulo"/>
          </td>
          <!-- Segundo desplie el ISBN y la cat-->
          <td style="margin-left:20px;margin-bottom:1em;font-size:15pt">
            <xsl:value-of select="@Categoria"/>
          </td>
          <!-- Tercero desplie el ISBN y la cat-->
          <td style="margin-left:20px;margin-bottom:1em;font-size:15pt">
            ISBN <xsl:value-of select="ISBN"/>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
