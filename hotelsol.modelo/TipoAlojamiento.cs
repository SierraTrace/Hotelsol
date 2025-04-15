using System.ComponentModel.DataAnnotations;

public enum TipoAlojamiento
{
    [Display(Name = "Solo Alojamiento")]
    SOLO_ALOJAMIENTO,

    [Display(Name = "Desayuno")]
    DESAYUNO,

    [Display(Name = "Media Pensión")]
    MEDIA_PENSION,

    [Display(Name = "Pensión Completa")]
    PENSION_COMPLETA,

    [Display(Name = "Todo Incluido")]
    TODO_INCLUIDO
}
