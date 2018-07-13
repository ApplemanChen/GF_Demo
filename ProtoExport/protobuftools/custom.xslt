<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>

<xsl:import href="common.xslt"/>

 <!-- 自定义模版 -->
 <!-- 变量区 -->


 <!-- 定义获取基类名方法 -->
  <xsl:template name="getBaseClassName">
 	 <xsl:variable name = "className" ><xsl:call-template name="pascal"/></xsl:variable>
     <xsl:choose >
     	<xsl:when test="starts-with($className,'sc_')"> : SCPacketBase</xsl:when>
     	<xsl:when test="starts-with($className,'cs_')"> : CSPacketBase</xsl:when>
     	<xsl:otherwise></xsl:otherwise>
     </xsl:choose>
  </xsl:template>

<!-- 是否显示Clear方法模版 -->
  <xsl:template name="methodClear">
 	 <xsl:variable name = "className" ><xsl:call-template name="pascal"/></xsl:variable>
     <xsl:choose>
     	<xsl:when test="starts-with($className,'sc_') or starts-with($className,'cs_')"> 
	public override void Clear()
	{   
	  //TODO
	}
     	</xsl:when>
     	<xsl:otherwise></xsl:otherwise>
     </xsl:choose>
  </xsl:template>

</xsl:stylesheet>
