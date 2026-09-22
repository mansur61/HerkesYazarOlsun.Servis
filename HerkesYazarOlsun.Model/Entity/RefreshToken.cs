using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    /// <summary>
    /// Kullanıcıya ait refresh token kaydı. DB'de tutulur.
    /// </summary>
    [Table("RefreshTokens")]
    public class RefreshToken : NewBaseEntity
    {
        public long   UserId     { get; set; }
        public string Token      { get; set; } = "";
        public DateTime ExpiresAt  { get; set; }
        public DateTime CreatedAt  { get; set; } = DateTime.UtcNow;
        public DateTime? RevokedAt { get; set; }

        [NotMapped] public bool IsRevoked => RevokedAt.HasValue;
        [NotMapped] public bool IsExpired  => DateTime.UtcNow >= ExpiresAt;
        [NotMapped] public bool IsActive   => !IsRevoked && !IsExpired;

        // Navigation
        public virtual Users? User { get; set; }
    }
}
